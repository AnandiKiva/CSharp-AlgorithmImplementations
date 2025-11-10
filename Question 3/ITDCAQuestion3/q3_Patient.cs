using System;

namespace ITDCAQuestion3
{
    
    
    // Simple patient record for the clinic queue.
    
    public class q3_Patient
    {
        public string Name { get; set; }
        // Priority 0 = highest urgency, 4 = lowest urgency 
        public int Priority { get; set; }
        public DateTime TimeArrived { get; set; }

        public q3_Patient(string name, int priority)
        {
            Name = name;
            Priority = priority;
            TimeArrived = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Name} (priority {Priority})";
        }
    }
}

