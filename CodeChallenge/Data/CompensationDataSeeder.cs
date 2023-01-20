﻿using CodeChallenge.Models;
using CodeChallenge.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data
{
    public class CompensationDataSeeder
    {
        private CompensationContext _compensationContext;
        private const String COMPENSATION_SEED_DATA_FILE = "resources/CompensationSeedData.json";

        public CompensationDataSeeder(CompensationContext compensationContext)
        {
            _compensationContext = compensationContext;
        }

        public async Task Seed()
        {
            if(!_compensationContext.Compensation.Any())
            {
                List<Compensation> compensation = LoadCompensation();
                _compensationContext.AddRange(compensation);

                await _compensationContext.SaveChangesAsync();
            }
        }
        private List<Compensation> LoadCompensation()
        {
            using (FileStream fs = new FileStream(COMPENSATION_SEED_DATA_FILE, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            using (JsonReader jr = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                List<Compensation> compensation = serializer.Deserialize<List<Compensation>>(jr);

                return compensation;
            }
        }
    }
}
