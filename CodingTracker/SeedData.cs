﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal static class SeedData
    {
        internal static void SeedRecords(int count)
        {
            Random random = new Random();
            DateTime currentDate = DateTime.Now.Date; // Start with today's date

            List<CodingRecord> records = new List<CodingRecord>();

            for (int i = 1; i <= count; i++)
            {
                DateTime startDate = currentDate.AddHours(random.Next(13));
                DateTime endDate = startDate.AddHours(random.Next(13));

                records.Add(new CodingRecord
                {
                    Id = i,
                    DateStart = startDate,
                    DateEnd = endDate,
                });

                // Increment the date for the next record
                currentDate = currentDate.AddDays(1);
            }

            var dataAccess = new DataAccess();
            dataAccess.BulkInsertRecords(records);
        }
    }
}
