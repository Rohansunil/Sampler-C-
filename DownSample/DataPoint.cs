using System;
using System.Collections.Generic;
using System.Text;

    abstract class DataPoint
    {
        string _time;
        int _value;

        public string Time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }

        public int Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }


