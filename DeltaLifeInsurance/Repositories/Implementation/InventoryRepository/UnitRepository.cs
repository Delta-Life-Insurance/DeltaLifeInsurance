using DeltaLifeInsurance.GenericClass;
using DeltaLifeInsurance.Models.Inventory;
using DeltaLifeInsurance.Repositories.Contract;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;


namespace DeltaLifeInsurance.Repositories.Implementation.InventoryRepository
{
    public class UnitRepository : IGenericRepository<Unit>
    {
        private readonly string _SQLString = "";      
        ServiceHandler _handler=new ServiceHandler();
        public UnitRepository(IConfiguration configuration)
        {
           // _SQLString = configuration.GetConnectionString("SQLString");
          
            
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Unit model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Unit>> List()
        {
            List<Unit> _list = new List<Unit>();
            
               var test = _handler.ReturnString("select UnitName from Inv_Unit");
            using (var conexion = new SqlConnection(_SQLString))
            {      // Create conexion
                conexion.Open();    // Open conexion
                SqlCommand cmd = new SqlCommand("sp_listUnit", conexion);    // Specify command (Storage procedure)
                cmd.CommandType = CommandType.StoredProcedure;      // Specify command type

                // Read stored data
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        _list.Add(new Unit
                        {
                            UnitId = Convert.ToInt32(dr["UnitId"]),
                            UnitName = dr["UnitName"].ToString(),                           
                            UnitDescription = dr["UnitDescription"].ToString(),                            
                        });
                    }
                }
            }

            return _list;
        }

       
     
        public Task<bool> Save(Unit model)
        {
            throw new NotImplementedException();
        }
    }
}
