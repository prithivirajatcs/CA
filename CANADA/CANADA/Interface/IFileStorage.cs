using System;
using CANADA.Model;

namespace CANADA.Interface
{
    public interface IFileStorage
    {
        
        string getpath(string json);
        string readdata(string filename);
    }
}
