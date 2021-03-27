using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public interface IHistory<T>
    {
        T this[ int _index ] { get; }
        IReadOnlyList<T> History { get; }

        void AddHistory ( T _entry );
        void RemoveHistory ( T _entry );
    }
}