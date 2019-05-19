using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomains.Core
{
    public class DataSourceValue<TValue>
    {
        public TValue Value { set; get; }
        public string DisplayName { set; get; }
    }
}
