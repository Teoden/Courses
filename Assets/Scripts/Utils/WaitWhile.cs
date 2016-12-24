using System;
using System.Collections;

namespace Courses
{
    public class WaitWhile : IEnumerator
    {

        Func<bool> m_Predicate;

        public object Current { get { return null; } }

        public bool MoveNext() { return m_Predicate(); }

        public void Reset() { }

        public WaitWhile(Func<bool> predicate) { m_Predicate = predicate; }
    }
}


