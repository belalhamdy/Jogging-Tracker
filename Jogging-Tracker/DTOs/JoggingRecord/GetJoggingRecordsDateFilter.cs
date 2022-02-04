using System;

namespace Jogging_Tracker.DTOs.JoggingRecord
{
    public class GetJoggingRecordsDateFilter
    {
        public DateTime From { get; set; } = DateTime.MinValue;
        public DateTime To { get; set; } = DateTime.MaxValue;
    }
}