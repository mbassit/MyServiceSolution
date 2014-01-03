using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyServiceDll
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in App.config.
    [ServiceContract]
    public interface IMyServiceDll
    {
        [OperationContract]
        string MessageBack(string fromClient);

        [OperationContract]
        double RemoteCalc(double n);
    }

}
