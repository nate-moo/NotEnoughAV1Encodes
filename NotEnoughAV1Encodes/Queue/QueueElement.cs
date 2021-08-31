﻿using System.ComponentModel;

namespace NotEnoughAV1Encodes.Queue
{
    public class QueueElement : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double _progress;

        public string Input { get; set; }
        public string Output { get; set; }
        public string InputFileName { get; set; }
        public string OutputFileName { get; set; }
        public string Status { get; set; }
        public string VideoCommand { get; set; }
        public string AudioCommand { get; set; }
        public double Progress
        {
            get => _progress;
            set { _progress = value; NotifyPropertyChanged("Progress"); }
        }
        
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayMember"));
            }
        }
    }
}