using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiThreadDemo
{
    public class Cortex : ICortex
    {
        public Cortex()
        {
            throw new System.NotImplementedException();
        }
    }

    public class CortexInput : Cortex
    {
        public CortexInput()
        {
            throw new System.NotImplementedException();
        }

        ~CortexInput()
        {
            throw new System.NotImplementedException();
        }
    }

    public class CortexOutput : Cortex
    {
        public CortexOutput()
        {
            throw new System.NotImplementedException();
        }

        ~CortexOutput()
        {
            throw new System.NotImplementedException();
        }
    }

    public class CortexSolve : Cortex
    {
        public CortexSolve()
        {
            throw new System.NotImplementedException();
        }

        ~CortexSolve()
        {
            throw new System.NotImplementedException();
        }
    }

    public class CortexIdentify : Cortex
    {
        public CortexIdentify()
        {
            throw new System.NotImplementedException();
        }

        ~CortexIdentify()
        {
            throw new System.NotImplementedException();
        }
    }

    public class CortexTransform : Cortex
    {
        public CortexTransform()
        {
            throw new System.NotImplementedException();
        }

        ~CortexTransform()
        {
            throw new System.NotImplementedException();
        }
    }

    public struct CortexConnection
    {
        public int Content { set; get; }
    }

    public interface ICortex
    {
        CortexConnection InputConnection { get; set; }
        CortexConnection OutputConnection { get; set; }
        Int32 identity { get; set; }
        InternalData InternalData { get; set; }
        CortexConfiguration CortexConfiguration { get; set; }

        void Process();
    }

    public struct InternalData
    {
    }

    public struct CortexConfiguration
    {
    }
}