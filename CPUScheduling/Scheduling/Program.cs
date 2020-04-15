//Program for CPU Scheduling 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSchedulingAOS
{
    public class cpuSchedule
    {
        int n;
        int[] Bu = new int[20];
        float Twt, Awt, w, tat, atat;
        float[] A = new float[10];
        float[] Wt = new float[10];
        float at = 0;
        float[] previousState = new float[10];
        public void Getdata()
        {
            int i;
            Console.WriteLine("Enter the no of process:");
            n = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter the brust time of Process P" + i + "=");
                Bu[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        //First Come First Serve
        public void Fcfs()
        {
            int i;
            int[] B = new int[10];
            Twt = 0;
            for (i = 1; i <= n; i++)
            {
                B[i] = Bu[i];
                at += B[i];
                Console.WriteLine("\nBurst time for process p" + i + "=" + B[i]);
                // Console.WriteLine(B[i]);
            }
            Wt[1] = 0;
            for (i = 2; i <= n; i++)
            {
                Wt[i] = B[i - 1] + Wt[i - 1];
            }

            //Calculating Average Weighting Time
            for (i = 1; i <= n; i++)
            {
                Twt = Twt + Wt[i];
            }
            tat = Twt + at;
            atat = tat / n;
            Awt = Twt / n;
            Console.WriteLine("Total Weighting Time =" + Twt);
            Console.WriteLine("Average Weighting Time=" + Awt);
            Console.WriteLine("Total Turn Around Time=" + tat);
            Console.WriteLine("Average Turn Around Time=" + atat);
        } 
        //First come First served Algorithm
        public void Sjf()
        {
            int i, j, temp;
            int[] B = new int[10]; //here B[] stores the sorted burst time of process.
            Twt = 0;
            for (i = 1; i <= n; i++)
            {
                B[i] = Bu[i];
                at += B[i];
                Console.WriteLine("\nBurst time for process p" + i + "=");
                Console.WriteLine(B[i]);
            }
            for (i = n; i >= 1; i--) // sort the process according to the increasing order of burst time i.e bubble sort
            {
                for (j = 1; j <= n; j++)
                {
                    if (B[j - 1] > B[j])
                    {
                        temp = B[j - 1];
                        B[j - 1] = B[j];
                        B[j] = temp;
                    }
                }
            }
            Wt[1] = 0;
            for (i = 2; i <= n; i++)
            {
                Wt[i] = B[i - 1] + Wt[i - 1];
            }

            for (i = 1; i <= n; i++)
            {
                Twt = Twt + Wt[i];
            }
            tat = Twt + at;
            atat = tat / n;
            Awt = Twt / n;
            //cout << " Total Weighting Time=" << Twt;
            //cout << "Average Weighting Time=" << Awt << " ";
            Console.WriteLine("Total Weighting Time =" + Twt);
            Console.WriteLine("Average Weighting Time=" + Awt);
            Console.WriteLine("Total Turn Around Time=" + tat);
            Console.WriteLine("Average Turn Around Time=" + atat);
        } //Shortest job First Algorithm
        public void Priority()
        {
            int i, j, temp;
            int[] B = new int[10];
            int[] P = new int[10];
            w = 0;
            int max;
            Twt = 0;
            max = 1;
            for (i = 1; i <= n; i++)
            {
                B[i] = Bu[i];
                at += B[i];
                Console.WriteLine("\nBurst time for process p" + i + "=" + B[i]);
                //   Console.WriteLine(B[i]);
                Console.WriteLine(" Enter the priority for process P" + i + "=");
                P[i] = Convert.ToInt32(Console.ReadLine());
                if (max < P[i])
                    max = P[i];
                
            }
            j = 1;
            while (j <= max) //calculate the waiting time for each process
            {
                i = 1;
                while (i <= n)
                {
                    if (P[i] == j) //search for highest priority(lowest value) process
                    {
                        Wt[i] = w;
                        w = w + B[i]; // previous burst time is the waiting time for next process
                    }
                    i++;
                }
                j++;
            }
            for (int k = 1; k <= n; k++)
            {
                for (int z = k + 1; z <= n; z++)
                {
                    if (P[k] > P[z])
                    {
                        temp = B[k];
                        B[k] = B[z];
                        B[z] = temp;
                    }
                }
            }
            //Calculating average waiting Time
            for (i = 1; i <= n; i++)
            {
                Twt = Twt + Wt[i];
            }
            tat = Twt + at;
            atat = tat / n;
            Awt = Twt / n;
            Console.WriteLine("Total Weighting Time =" + Twt);
            Console.WriteLine("Average Weighting Time=" + Awt);
            Console.WriteLine("Total Turn Around Time=" + tat);
            Console.WriteLine("Average Turn Around Time=" + atat);
        } 
        
        //Implementation of Priority Algorithm
        public void SjfP()
        {
            int i;
            int[] B = new int[10];
            int[] rt = new int[10];
            int[] art = new int[10];
            for (i = 1; i <= n; i++)
            {
                Console.WriteLine("\n Arrival time for process p" + i + "=");
                art[i] = Convert.ToInt32(Console.ReadLine());
            }
            Twt = 0;
            for (i = 1; i <= n; i++)
            {
                B[i] = Bu[i];
                rt[i] = B[i];
                at += B[i];
                Console.WriteLine("\nBurst time for process p" + i + "=" + B[i]);
            }
            int complete = 0, t = 0, minm = int.MaxValue;
            int shortest = 0, finish_time = 0;
            bool check = false;
            int totaltimeForexexecution = 0;
            for (int k = 1; k <= n; k++)
            {
                totaltimeForexexecution += B[k];
            }
            while (complete != totaltimeForexexecution)
            {

                // Find process with minimum remaining time among the processes that arrives till the current time
                for (int j = 1; j <= n; j++)
                {
                    if ((art[j] <= t) &&
                    (rt[j] < minm) && rt[j] > 0)
                    {
                        minm = rt[j];
                        shortest = j;
                        check = true;
                    }
                }
                // Reduce remaining time by one 
                rt[shortest]--;

                // Update minimum 
                minm = rt[shortest];
                if (minm == 0)
                    minm = int.MaxValue;
                {

                    // Increment complete 
                    complete++;
                    check = false;
                    finish_time++;
                    Wt[shortest] += (finish_time - previousState[shortest] - 1);
                    previousState[shortest] = finish_time;

                    if (Wt[shortest] < 0)
                        Wt[shortest] = 0;
                }
                // Increment time 
                t++;
            }
            for (i = 1; i <= n; i++)
            {
                Twt = Twt + Wt[i];
            }
            tat = Twt + at;
            atat = tat / n;
            Awt = Twt / n;
            //cout << " Total Weighting Time=" << Twt;
            //cout << "Average Weighting Time=" << Awt << " ";
            Console.WriteLine("Total Weighting Time =" + Twt);
            Console.WriteLine("Average Weighting Time=" + Awt);
            Console.WriteLine("Total Turn Around Time=" + tat);
            Console.WriteLine("Average Turn Around Time=" + atat);
        }//Shortest job First Algorithm with Preemption
        public void RoundRobin()
        {
            int i;
            int[] B = new int[10];
            int[] rem_bt = new int[10];
            Twt = 0;
            Console.WriteLine("Enter the Quantum size:Q=");
            int quantum = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= n; i++)
            {
                B[i] = Bu[i];
                rem_bt[i] = B[i];
                at += B[i];
                Console.WriteLine("\nBurst time for process p" + i + "=" + B[i]);
            }
            int t = 0;
            Wt[1] = 0;
            int numberofcontextSwitch = 0;
            Console.WriteLine("Enter the Quantum size:Q=" + quantum);
            while (true)
            {
                bool done = true;

                // Traverse all processes one by 
                // one repeatedly 
                for (i = 1; i <= n; i++)
                {
                    if (rem_bt[i] == 0)
                        continue;
                    // If burst time of a process 
                    // is greater than 0 then only 
                    // need to process further 
                    if (rem_bt[i] > 0)
                    {

                        // There is a pending process 
                        done = false;

                        if (rem_bt[i] > quantum)
                        {
                            // Increase the value of t i.e. 
                            // shows how much time a process 
                            // has been processed 
                            t += quantum;
                            Wt[i] += (t - previousState[i] - quantum);
                            previousState[i] = t;

                            // Decrease the burst_time of  
                            // current process by quantum 
                            rem_bt[i] -= quantum;
                            numberofcontextSwitch++;
                        }

                        // If burst time is smaller than 
                        // or equal to quantum. Last cycle 
                        // for this process 
                        else
                        {

                            // Increase the value of t i.e. 
                            // shows how much time a process 
                            // has been processed 
                            t = t + rem_bt[i];

                            // Waiting time is current 
                            // time minus time used by  
                            // this process 
                            // Wt[i]+= (t - B[i]);
                            Wt[i] += (t - previousState[i] - rem_bt[i]);

                            // As the process gets fully  
                            // executed make its remaining 
                            // burst time = 0 
                            rem_bt[i] = 0;
                            numberofcontextSwitch++;
                        }
                    }
                    string DisplayRemainingBurstTime = "";
                    for (int x = 1; x <= n; x++)
                    {
                        DisplayRemainingBurstTime = DisplayRemainingBurstTime + "   " + rem_bt[x];
                    }
                    Console.WriteLine(DisplayRemainingBurstTime);
                }

                // If all processes are done 
                if (done == true)
                    break;
            }
            for (i = 1; i <= n; i++)
            {
                Twt = Twt + Wt[i];
            }
            tat = Twt + at;
            atat = tat / n;
            Awt = Twt / n;
            //cout << " Total Weighting Time=" << Twt;
            //cout << "Average Weighting Time=" << Awt << " ";
            Console.WriteLine("Total Weighting Time =" + Twt);
            Console.WriteLine("Average Weighting Time=" + Awt);
            Console.WriteLine("Total Turn Around Time=" + tat);
            Console.WriteLine("Average Turn Around Time=" + atat);
            Console.WriteLine("Number Of context Switch:" + --numberofcontextSwitch);// since one additional context switch is added at the beginning
        } 
        //Round Robin Algorithm
        public void WeightedRoundRobin()// here weight is assigned to process rather than processor
        {
            int i;
            int[] B = new int[10];
            int[] weight = new int[10];
            int[] rem_bt = new int[10];

            Twt = 0;
            Console.WriteLine("Enter the Quantum size:Q=");
            int quantum = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= n; i++)
            {
                B[i] = Bu[i];
                rem_bt[i] = B[i];
                at += B[i];
                Console.WriteLine("\nBurst time for process p" + i + "=" + B[i]);
                Console.WriteLine("Enter the Weight for  process p" + i);
                string check = Console.ReadLine();
                int value;
                if (int.TryParse(check, out value) && value >= 1)
                    weight[i] = Convert.ToInt32(check);
                else
                    weight[i] = 1;

            }
            int t = 0;
            Wt[1] = 0;
            int numberofcontextSwitch = 0;
            while (true)
            {
                bool done = true;

                // Traverse all processes one by 
                // one repeatedly 
                for (i = 1; i <= n; i++)
                {
                    if (rem_bt[i] == 0)
                        continue;
                    // If burst time of a process is greater than 0 then only need to process further 
                    // to change the quamtum size according to weight of process. 
                    if (weight[i] > 1)
                        quantum *= weight[i];
                    Console.WriteLine("quantum size=" + quantum + " for process p" + i);
                    if (rem_bt[i] > 0)
                    {
                        // There is a pending process 
                        done = false;

                        if (rem_bt[i] > quantum)
                        {
                            // Increase the value of t i.e. 
                            // shows how much time a process 
                            // has been processed 
                            t += quantum;
                            Wt[i] += (t - previousState[i] - quantum);
                            previousState[i] = t;
                            // Decrease the burst_time of  
                            // current process by quantum 
                            rem_bt[i] -= quantum;
                            numberofcontextSwitch++;
                        }

                        // If burst time is smaller than 
                        // or equal to quantum. Last cycle 
                        // for this process 
                        else
                        {

                            // Increase the value of t i.e. 
                            // shows how much time a process 
                            // has been processed 
                            t = t + rem_bt[i];

                            // Waiting time is current 
                            // time minus time used by  
                            // this process 
                            // Wt[i] = t - B[i];
                            Wt[i] += (t - previousState[i] - rem_bt[i]);


                            // As the process gets fully  
                            // executed make its remaining 
                            // burst time = 0 
                            rem_bt[i] = 0;
                            numberofcontextSwitch++;
                        }
                    }
                    string DisplayRemainingBurstTime = "";
                    for (int x = 1; x <= n; x++)
                    {
                        DisplayRemainingBurstTime = DisplayRemainingBurstTime + "   " + rem_bt[x];
                    }
                    Console.WriteLine(DisplayRemainingBurstTime);
                    quantum = quantum / weight[i];
                }

                // If all processes are done 
                if (done == true)
                    break;
            }
            for (i = 1; i <= n; i++)
            {
                Twt = Twt + Wt[i];
            }
            tat = Twt + at;
            atat = tat / n;
            Awt = Twt / n;
            //cout << " Total Weighting Time=" << Twt;
            //cout << "Average Weighting Time=" << Awt << " ";
            Console.WriteLine("Total Weighting Time =" + Twt);
            Console.WriteLine("Average Weighting Time=" + Awt);
            Console.WriteLine("Total Turn Around Time=" + tat);
            Console.WriteLine("Average Turn Around Time=" + atat);
            Console.WriteLine("Number Of context Switch:" + --numberofcontextSwitch);// since one additional context switch is added at the beginning
        }
        public void DynamicRoundRobinByMean()// here mean is used as quantum;
        {
            int i;
            int[] B = new int[10];
            int[] weight = new int[10];
            int[] rem_bt = new int[10];
            Twt = 0;
            int quantum;
            for (i = 1; i <= n; i++)
            {
                B[i] = Bu[i];
                rem_bt[i] = B[i];
                at += B[i];
                Console.WriteLine("\nBurst time for process p" + i + "=" + B[i]);
            }
            int t = 0;
            Wt[1] = 0;
            int numberofcontextSwitch = 0;
            int count;
            int remainingprocesscount;
            while (true)
            {
                bool done = true;

                // Traverse all processes one by 
                // one repeatedly 
                for (i = 1; i <= n; i++)
                {
                    count = 0;
                    remainingprocesscount = 0;
                    if (rem_bt[i] == 0)
                        continue;
                    // If burst time of a process 
                    // is greater than 0 then only 
                    // need to process further 
                    // to change the quamtum size according to weight of process;
                    int totalbrusttime = 0;
                    for (int j = 1; j <= n; j++)
                    {
                        if (i != j)
                        {
                            totalbrusttime += rem_bt[j];
                            if (rem_bt[j] != 0)
                                count++;
                        }
                        if (rem_bt[j] != 0)
                        {
                            remainingprocesscount++;
                        }

                    }
                    if (remainingprocesscount == 1)  //to terminate last process
                    {
                        if (totalbrusttime == 0)//only if one process is remaining
                        {
                            for (int j = 1; j <= n; j++)
                            {
                                totalbrusttime += rem_bt[j];

                            }
                        }

                    }


                    //if (n != i)
                    if (count == 0)
                        count = 1;
                    //{
                    quantum = totalbrusttime / count;
                    Console.WriteLine("quantum size=" + quantum + " for process p" + i);
                    //}
                    //else
                    //{
                    //    quantum = rem_bt[i];
                    //    Console.WriteLine("quantum size=" + quantum);
                    //    //done = true;
                    //}


                    if (rem_bt[i] > 0)
                    {

                        // There is a pending process 
                        done = false;

                        if (rem_bt[i] > quantum)
                        {
                            // Increase the value of t i.e. 
                            // shows how much time a process 
                            // has been processed 
                            t += quantum;
                            Wt[i] += (t - previousState[i] - quantum);
                            previousState[i] = t;
                            // Decrease the burst_time of  
                            // current process by quantum 
                            rem_bt[i] -= quantum;
                            numberofcontextSwitch++;
                        }

                        // If burst time is smaller than 
                        // or equal to quantum. Last cycle 
                        // for this process 
                        else
                        {

                            // Increase the value of t i.e. 
                            // shows how much time a process 
                            // has been processed 
                            t = t + rem_bt[i];

                            // Waiting time is current 
                            // time minus time used by  
                            // this process 
                            // Wt[i] = t - B[i];
                            Wt[i] += (t - previousState[i] - rem_bt[i]);


                            // As the process gets fully  
                            // executed make its remaining 
                            // burst time = 0 
                            rem_bt[i] = 0;
                            numberofcontextSwitch++;
                        }
                    }
                    string DisplayRemainingBurstTime = "";
                    for (int x = 1; x <= n; x++)
                    {
                        DisplayRemainingBurstTime = DisplayRemainingBurstTime + "   " + rem_bt[x];
                    }
                    Console.WriteLine(DisplayRemainingBurstTime);
                    int totalremBurstTime = 0;
                    for (int f = 1; f <= n; f++)
                    {
                        totalremBurstTime += rem_bt[f];
                        if (f == n)
                        {
                            if (totalremBurstTime == 0)
                            {
                                done = true;
                            }
                        }
                    }

                }

                // If all processes are done 
                if (done == true)
                    break;
            }
            for (i = 1; i <= n; i++)
            {
                Twt = Twt + Wt[i];
            }
            tat = Twt + at;
            atat = tat / n;
            Awt = Twt / n;
            //cout << " Total Weighting Time=" << Twt;
            //cout << "Average Weighting Time=" << Awt << " ";
            Console.WriteLine("Total Weighting Time =" + Twt);
            Console.WriteLine("Average Weighting Time=" + Awt);
            Console.WriteLine("Total Turn Around Time=" + tat);
            Console.WriteLine("Average Turn Around Time=" + atat);
            Console.WriteLine("Number Of context Switch:" + --numberofcontextSwitch);// since one additional context switch is added at the beginning
        }
        public void DynamicRoundRobinByMedian()// here median is used as quantum;
        {
            int i;
            int[] B = new int[10];
            int[] weight = new int[10];
            int[] rem_bt = new int[10];
            Twt = 0;
            int quantum;
            for (i = 1; i <= n; i++)
            {
                B[i] = Bu[i];
                // rem_bt[i] = B[i];
                Console.WriteLine("\nBurst time for process p" + i + "=" + B[i]);
            }
            // to convert into ascending order
            for (int k = 1; k <= n; k++)
            {
                for (int z = k + 1; z <= n; z++)
                {
                    if (B[k] > B[z])
                    {
                        int temp = B[k];
                        B[k] = B[z];
                        B[z] = temp;
                    }
                }
            }
            for (i = 1; i <= n; i++)
            {
                rem_bt[i] = B[i];
                at += B[i];
            }
            int t = 0;
            Wt[1] = 0;
            int numberofcontextSwitch = 0;
            while (true)
            {
                bool done = true;

                // Traverse all processes one by 
                // one repeatedly 
                for (i = 1; i <= n; i++)
                {
                    // If burst time of a process 
                    // is greater than 0 then only 
                    // need to process further 
                    // to change the quamtum size according to weight of process;
                    //1,2,3,4,5
                    if (rem_bt[i] == 0)
                        continue;
                    double median;
                    int status = 0;// indicate the end data;
                    if (i != n)
                    {
                        median = (n + i + 1) / 2.0;
                    }
                    else
                    {
                        median = B[n];
                        status = 1;
                    }

                    int totalbrusttime = 0;
                    if (median % 1 == 0 && status == 0)
                    {
                        quantum = B[Convert.ToInt32(median)];
                    }
                    else if (median % i != 0 && status == 0)
                    {
                        int lower = Convert.ToInt32(Math.Ceiling(median));
                        int Upper = Convert.ToInt32(Math.Floor(median));
                        double actualMedian = (B[lower] + B[Upper]) / 2;
                        quantum = Convert.ToInt32(actualMedian);
                    }
                    else
                    {
                        quantum = Convert.ToInt32(median);
                    }
                    Console.WriteLine("quantum size=" + quantum + " for process p" + i);
                    //for (int j = i + 1; j <= n; j++)
                    //{
                    //    totalbrusttime += rem_bt[j];
                    //}
                    //if (n != i)
                    //{
                    //    quantum = totalbrusttime / (n - i);
                    //    Console.WriteLine("quantum size=" + quantum);
                    //}
                    //else
                    //{
                    //    quantum = rem_bt[i];
                    //    Console.WriteLine("quantum size=" + quantum);
                    //    //done = true;
                    //}


                    if (rem_bt[i] > 0)
                    {

                        // There is a pending process 
                        done = false;

                        if (rem_bt[i] > quantum)
                        {
                            // Increase the value of t i.e. 
                            // shows how much time a process 
                            // has been processed 
                            t += quantum;
                            Wt[i] += (t - previousState[i] - quantum);
                            previousState[i] = t;
                            // Decrease the burst_time of  
                            // current process by quantum 
                            rem_bt[i] -= quantum;
                            numberofcontextSwitch++;
                        }

                        // If burst time is smaller than 
                        // or equal to quantum. Last cycle 
                        // for this process 
                        else
                        {

                            // Increase the value of t i.e. 
                            // shows how much time a process 
                            // has been processed 
                            t = t + rem_bt[i];

                            // Waiting time is current 
                            // time minus time used by  
                            // this process 
                            //Wt[i] = t - B[i];
                            Wt[i] += (t - previousState[i] - rem_bt[i]);

                            // As the process gets fully  
                            // executed make its remaining 
                            // burst time = 0 
                            rem_bt[i] = 0;
                            numberofcontextSwitch++;
                        }
                    }
                    string DisplayRemainingBurstTime = "";
                    for (int x = 1; x <= n; x++)
                    {
                        DisplayRemainingBurstTime = DisplayRemainingBurstTime + "   " + rem_bt[x];
                    }
                    Console.WriteLine(DisplayRemainingBurstTime);
                    if (i == n)
                    { done = true; }
                }

                // If all processes are done 
                if (done == true)
                    break;
            }
            for (i = 1; i <= n; i++)
            {
                Twt = Twt + Wt[i];
            }
            tat = Twt + at;
            atat = tat / n;
            Awt = Twt / n;
            Console.WriteLine("Total Weighting Time =" + Twt);
            Console.WriteLine("Average Weighting Time=" + Awt);
            Console.WriteLine("Total Turn Around Time=" + tat);
            Console.WriteLine("Average Turn Around Time=" + atat);
            Console.WriteLine("Number Of context Switch:" + --numberofcontextSwitch);// since one additional context switch is added at the beginning
        }

        static void Main(string[] args)
        {
            bool ReenterData = false;
            do
            {
                cpuSchedule obj = new cpuSchedule();
                obj.Getdata();
                Console.WriteLine(" Select the Scheduling Algorithm By entering the Digit shown below\n");
                Console.WriteLine(" First Come First Service 1\n");
                Console.WriteLine(" Shortest Job First 2\n");
                Console.WriteLine(" Shortest Job First Preemption 3\n");
                Console.WriteLine(" Priority Scheduling 4\n");
                Console.WriteLine(" Round Robin 5\n");
                Console.WriteLine("Weighted Round Robin according to process Weight 6\n");
                Console.WriteLine("Dynamic Round Robin according to mean as Quantum 7\n");
                Console.WriteLine("Dynamic Round Robin according to Median as Quantum 8\n");
                int SchedulingType = Convert.ToInt32(Console.ReadLine());
                switch (SchedulingType)
                {
                    case 1:
                        {
                            obj.Fcfs();
                            break;
                        }
                    case 2:
                        {
                            obj.Sjf();
                            break;
                        }
                    case 3:
                        {
                            obj.SjfP();
                            break;
                        }
                    case 4:
                        {
                            obj.Priority();
                            break;
                        }
                    case 5:
                        {
                            obj.RoundRobin();
                            break;
                        }
                    case 6:
                        {
                            obj.WeightedRoundRobin();
                            break;
                        }
                    case 7:
                        {
                            obj.DynamicRoundRobinByMean();
                            break;
                        }
                    case 8:
                        {
                            obj.DynamicRoundRobinByMedian();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please select valid Number");
                            break;
                        }
                }

                Console.WriteLine("Do you want to exit Process? true/false");
                ReenterData = Convert.ToBoolean(Console.ReadLine());
            } while (ReenterData != true);

            Console.ReadKey();



        }
    }
}
