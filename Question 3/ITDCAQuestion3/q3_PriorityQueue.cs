using System;
using System.Collections.Generic;

namespace ITDCAQuestion3
{
    // Priority queue implemented as an array of FIFO queues.
    // Priority queue implemented as an array of FIFO queues.
    // Index 4 = lowest priority queue (least urgent).
    public class q3_PriorityQueue
    {
        private readonly Queue<q3_Patient>[] queues;
        public int MaxPriority { get; } = 4;

        public q3_PriorityQueue()
        {
            queues = new Queue<q3_Patient>[MaxPriority + 1];
            for (int i = 0; i <= MaxPriority; i++)
                queues[i] = new Queue<q3_Patient>();
        }

        // Enqueue a patient into the queue with given priority (0..4).
        public void Enqueue(q3_Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            if (patient.Priority < 0 || patient.Priority > MaxPriority)
                throw new ArgumentOutOfRangeException(nameof(patient.Priority), $"Priority must be between 0 and {MaxPriority}.");

            queues[patient.Priority].Enqueue(patient);
        }

        // Dequeue the highest-priority patient available (lowest numeric priority).
        public q3_Patient Dequeue()
        {
            for (int p = 0; p <= MaxPriority; p++)
            {
                if (queues[p].Count > 0)
                    return queues[p].Dequeue();
            }
            return null;
        }


        // Peek at the next patient to be dequeued without removing them.
        public q3_Patient Peek()
        {
            for (int p = 0; p <= MaxPriority; p++)
            {
                if (queues[p].Count > 0)
                    return queues[p].Peek();
            }
            return null;
        }

        public bool IsEmpty()
        {
            for (int p = 0; p <= MaxPriority; p++)
                if (queues[p].Count > 0) return false;
            return true;
        }

        // Number of patients currently in the system.
        public int Count()
        {
            int total = 0;
            for (int p = 0; p <= MaxPriority; p++)
                total += queues[p].Count;
            return total;
        }

        // Returns a readable snapshot of the queue for display.
        public string DumpQueue()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int p = 0; p <= MaxPriority; p++)
            {
                sb.AppendLine($"Priority {p} (urgent={p}):");
                if (queues[p].Count == 0)
                    sb.AppendLine("  <empty>");
                else
                {
                    foreach (var patient in queues[p])
                        sb.AppendLine($"  {patient.Name} (arrived {patient.TimeArrived:HH:mm:ss})");
                }
            }
            return sb.ToString();
        }
    }
}
