﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearingMachineModels
{
    public class SimulationSystem
    {
        #region Inputs
        public int DowntimeCost { get; set; }
        public int RepairPersonCost { get; set; }
        public int BearingCost { get; set; }
        public int NumberOfHours { get; set; }
        public int NumberOfBearings { get; set; }
        public int RepairTimeForOneBearing { get; set; }
        public int RepairTimeForAllBearings { get; set; }
        public List<TimeDistribution> DelayTimeDistribution { get; set; }
        public List<TimeDistribution> BearingLifeDistribution { get; set; }
        #endregion

        #region Outputs
        public List<CurrentSimulationCase> CurrentSimulationTable { get; set; }
        public PerformanceMeasures CurrentPerformanceMeasures { get; set; }
        public List<ProposedSimulationCase> ProposedSimulationTable { get; set; }
        public PerformanceMeasures ProposedPerformanceMeasures { get; set; }
        #endregion

        #region TempData 
        public List<TimeDistribution> tempDelayTimeDist;
        public List<TimeDistribution> tempBearingLifeDist;
        #endregion

        public SimulationSystem()
        {
            DelayTimeDistribution = new List<TimeDistribution>();
            BearingLifeDistribution = new List<TimeDistribution>();

            CurrentSimulationTable = new List<CurrentSimulationCase>();
            CurrentPerformanceMeasures = new PerformanceMeasures();

            ProposedSimulationTable = new List<ProposedSimulationCase>();
            ProposedPerformanceMeasures = new PerformanceMeasures();
        }

        public void Simulate()
        {
            throw new NotImplementedException();
        }

        public void InitializationDistributions()
        {
            //Fill Delay Time Distribution
            tempDelayTimeDist = new List<TimeDistribution>();
            tempDelayTimeDist = DelayTimeDistribution;
            HelperFunctions.CalcCummulativeProbability(ref tempDelayTimeDist);
            HelperFunctions.CalcRandomDigitAssignment(ref tempDelayTimeDist);
            DelayTimeDistribution = tempDelayTimeDist;

            //Fill Bearing life distribution
            tempBearingLifeDist = new List<TimeDistribution>();
            tempBearingLifeDist = BearingLifeDistribution;
            HelperFunctions.CalcCummulativeProbability(ref tempBearingLifeDist);
            HelperFunctions.CalcRandomDigitAssignment(ref tempBearingLifeDist);
            BearingLifeDistribution = tempBearingLifeDist;
        }

    }
}
