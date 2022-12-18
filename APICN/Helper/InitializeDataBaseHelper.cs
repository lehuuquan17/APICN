using API_HTGT.Context;
using API_HTGT.DAO;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using static APICN.Models.Dvhcvn;

namespace APICN.Helper
{
    public static class InitializeDataBaseHelper
    {
        public static void InitData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    List<Datum> configs = new List<Datum>();
                    bool IsCreateData = false;
                    if (IsCreateData)
                    {
                        configs = scope.ServiceProvider.GetService<IOptions<List<Datum>>>().Value!;
                    }

                    using (var context = scope.ServiceProvider.GetRequiredService<MyDBcontext>())
                    {
                        context.Database.EnsureCreated();
                        if (!context.Users.Any())
                        {
                            context.Add(new QuocGiaa()
                            {
                                LoaiQuocGia = "1",
                                MaDienThoai = "+84",
                                TenChinhThuc = "VietNam",
                                TenGoiChung = "Việt Nam",
                                Tinhthanhphos = configs?.Select(p => new Tinhthanhpho()
                                {
                                    tentinhthanh = p.name,
                                    Huyens = p.level2s?.Select(q => new DAO.huyen()
                                    {
                                        tenhuyen = q.name,
                                        phuongs = q.level3s?.Select(z => new phuonghuyen()
                                        {
                                            tenphuong = z.name
                                        }).ToList() ?? new List<phuonghuyen>()
                                    }).ToList() ?? new List<DAO.huyen>()
                                }).ToList() ?? new List<Tinhthanhpho>()
                            });
                            context.Add(new ChucVu()
                            {
                                Ten_ChucVu = "quanle",
                                Users = new List<User>()
                                {
                                    new User()
                                    {
                                        HOTEN = "lehuuquan",
                                        UserName = "quanle",
                                        PassWord = "123",
                                        Email = "quanle@gmail.com",
                                        TrangThai = "string",
                                    }
                                }
                            });
                            context.SaveChanges();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
