using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace MSC.Extensions
{
    public class ColumnChangeTracker
    {
        public static List<string> GetChangedColumns(Array array)
        {

            int maxIndex = array.Length - 1;
            List<string> columns = new List<string>();
            
            for (int index = 0; index < maxIndex; index++)
            {
                var current = array.GetValue(index);
                var prev = array.GetValue(index + 1);
                PropertyInfo[] prevProperties = prev.GetType().GetProperties()
                    .Where(x=> 
                        !x.Name.Equals("StartTime") && 
                        !x.Name.Equals("EndTime"))
                    .ToArray();
                PropertyInfo[] currProperties = current.GetType().GetProperties().Where(x => !x.Name.Equals("StartTime") && !x.Name.Equals("EndTime")).ToArray();
                int maxPropIndex = prevProperties.Length;
                var user = currProperties.FirstOrDefault(x => x.Name.Equals("ModifiedBy", StringComparison.InvariantCultureIgnoreCase));
                if (user != null)
                {
                    columns.Add($"`{user.GetValue(current)}` has changed: ");
                }
                else
                {
                    columns.Add("`Unknown` has changed: ");
                }
                for (int propIndex = 0; propIndex < maxPropIndex; propIndex++)
                {
                    if (!prevProperties[propIndex].GetValue(prev).Equals(currProperties[propIndex].GetValue(current)))
                    {
                        columns.Add(($"\tColumn `{prevProperties[propIndex].Name}` " +
                            $"from `{prevProperties[propIndex].GetValue(prev)}` " +
                            $"to `{currProperties[propIndex].GetValue(current)}`"));
                    }

                }

                columns.Add("\n");
                if (index+1 == maxIndex)
                {
                    var creatorObj = prevProperties.FirstOrDefault(x => x.Name.Equals("CreatedBy", StringComparison.InvariantCultureIgnoreCase));
                    var createdDateObj = prevProperties.FirstOrDefault(x => x.Name.Equals("CreatedDate", StringComparison.InvariantCultureIgnoreCase));
                    if(creatorObj!=null && createdDateObj != null)
                    {
                        columns.Add($"`{(creatorObj.GetValue(prev)==null?"Unknown": (creatorObj.GetValue(prev).ToString()))}` created this data at `{(createdDateObj.GetValue(prev)==null?"Unknown":createdDateObj.GetValue(prev).ToString())}`");
                    }
                }

            }
            return columns;
        }
    }
}
