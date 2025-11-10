using System;
using System.Runtime.CompilerServices;

namespace ITDCAQuestion3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Clinic Priority Queue (Question 3) ===");
            Console.WriteLine("Commands:");
            Console.WriteLine("  ENQUEUE <name> <priority>   (priority 0..4, 0 = most urgent)");
            Console.WriteLine("  DEQUEUE                     (dequeue and print patient)");
            Console.WriteLine("  PEEK                        (show next patient)");
            Console.WriteLine("  DUMP                        (show full queue state)");
            Console.WriteLine("  COUNT                       (show total patients)");
            Console.WriteLine("  EXIT                        (quit program)");
            Console.WriteLine();

            q3_PriorityQueue pq = new q3_PriorityQueue();

            while (true)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Trim().Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
                var cmd = parts[0].ToUpperInvariant();

                try
                {
                    switch (cmd)
                    {
                        case "ENQUEUE":
                            {
                                if (parts.Length < 3)
                                {
                                    Console.WriteLine("Usage: ENQUEUE <name> <priority>");
                                    break;
                                }

                                string name = parts[1];
                                // if the name may contain spaces, use different parsing; here we use simple 2nd and 3rd tokens
                                if (!int.TryParse(parts[2], out int priority))
                                {
                                    Console.WriteLine("Priority must be an integer between 0 and 4.");
                                    break;
                                }

                                var p = new q3_Patient(name, priority);
                                pq.Enqueue(p);
                                Console.WriteLine($"Enqueued: {p.Name} (priority {p.Priority})");
                                break;
                            }

                        case "DEQUEUE":
                            {
                                var patient = pq.Dequeue();
                                if (patient == null)
                                {
                                    Console.WriteLine("Queue empty. No patient to dequeue.");
                                }
                                else
                                {
                                    /// Program should print whenever a patient is dequeued
                                    Console.WriteLine($"Dequeued: {patient.Name} (priority {patient.Priority})");
                                }
                                break;
                            }

                        case "PEEK":
                            {
                                var next = pq.Peek();
                                if (next == null) Console.WriteLine("Queue empty.");
                                else Console.WriteLine($"Next: {next.Name} (priority {next.Priority})");
                                break;
                            }

                        case "DUMP":
                            Console.WriteLine(pq.DumpQueue());
                            break;

                        case "COUNT":
                            Console.WriteLine($"Total patients: {pq.Count()}");
                            break;

                        case "EXIT":
                            Console.WriteLine("Exiting program.");
                            return;

                        default:
                            Console.WriteLine("Unknown command. Use ENQUEUE, DEQUEUE, PEEK, DUMP, COUNT, or EXIT.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
