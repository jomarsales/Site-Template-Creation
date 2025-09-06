using System.Data;

namespace J3d.Domain.Delegate
{
    public class ConvertIDataReaderToIEntity
    {
        public delegate Entity.Entity ConvertIDataReaderToIEntityDelegate(IDataReader reader);
    }
}
