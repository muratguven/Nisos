﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.MongoDb.test
{
    public interface ITestFace<TTest>
        where TTest:class
    {
    }
}