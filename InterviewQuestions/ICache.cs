﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    interface ICache<K,V>
    {
        V Get(K key);
        void Set(K key, V value);
    }
}
