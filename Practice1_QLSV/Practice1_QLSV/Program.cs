
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Practice1_QLSV.Lib;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Practice1_QLSV
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            QLSV danhSachSV = new QLSV();
            danhSachSV.GetJSON("../../Data/Sinhvien.json");

            QLMH danhSachMH = new QLMH();
            danhSachMH.GetJSON("../../Data/Monhoc.json");

            QLMonDangKy danhSachMonDangKy = new QLMonDangKy();
            danhSachMonDangKy.GetJSON("../../Data/Mondangky.json");


            int choice = -1;
            int MSSV;
            bool res;
            string MaMH;
            while (choice != 0)
            {
                Console.WriteLine("----------Chức năng----------");
                Console.WriteLine("1. Xem danh sách sinh viên.");
                Console.WriteLine("2. Xem chi tiết sinh viên.");
                Console.WriteLine("3. Xem số môn học sinh viên đăng ký.");
                Console.WriteLine("4. Xem điểm môn học của sinh viên.");
                Console.WriteLine("5. Nhập điểm sinh viên.");
                Console.WriteLine("6. Xem kết quả trượt đỗ của sinh viên.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Nhập chức năng: ");
                Console.ResetColor();
                #region choice is an integer
                res = int.TryParse(Console.ReadLine(), out choice);
                if (!res)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nhập sai, vui lòng nhập lại");
                    Console.ResetColor();
                    choice = -1;
                    continue;
                }
                #endregion



                switch (choice)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Chương trình kết thúc.");
                        Console.ResetColor();
                        break;
                    case 1:
                        danhSachSV.XuatDanhSachSV();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Nhập mã sinh viên để xem thông tin: ");
                        Console.ResetColor();
                        #region MSSV is an integer
                        
                        res = int.TryParse(Console.ReadLine(), out MSSV);
                        if (!res)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Mã sinh viên phải là số nguyên.");
                            Console.ResetColor();
                            break;
                        }
                        #endregion
                        danhSachSV.ChiTietSV(MSSV);
                        break;
                    case 3:
                        danhSachMH.XuatDanhSachMH();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Nhập MSSV cần xem số môn học đăng ký:  ");
                        Console.ResetColor();
                        #region MSSV is an integer
                        res = int.TryParse(Console.ReadLine(), out MSSV);
                        if (!res)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Mã sinh viên phải là số nguyên.");
                            Console.ResetColor();
                            break;
                        }
                        #endregion
                        danhSachMonDangKy.SoMonHocSinhVienDangKy(MSSV);
                        break;
                    case 4:
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Nhập mã sinh viên cần xem điểm: ");

                            #region MSSV is an integer
                            res = int.TryParse(Console.ReadLine(), out MSSV);
                            if (!res)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Mã sinh viên phải là số nguyên.");
                                Console.ResetColor();
                                break;
                            }
                            #endregion
                            Console.ResetColor();
                            if (danhSachSV.ListSV.SingleOrDefault(x => x.MSSV == MSSV) == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Không tìm thấy sinh viên, vui lòng nhập lại");
                                Console.ResetColor();
                            }
                            else break;
                        }
                        if (!res) break;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Tên môn học", "Điểm quá trình", "Điểm thành phần", "Điểm tổng kết");
                        Console.ResetColor();
                        List<MonDangKy> ListMonDK = danhSachMonDangKy.ListMonDangKy.Where(x => x.MSSV == MSSV).ToList();
                        foreach (MonDangKy item in ListMonDK)
                        {
                            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", danhSachMH.ListMH.SingleOrDefault(x => x.MaMH == item.MaMH).TenMH, item.DQT, item.DTP, Math.Round((item.DQT + item.DTP) / 2, 2));
                        }
                        break;
                    case 5:
                        //Kiem tra MSSV
                        string write_json;

                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Nhập mã sinh viên cần nhập điểm: ");
                            #region MSSV is an integer
                            res = int.TryParse(Console.ReadLine(), out MSSV);
                            if (!res)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Mã sinh viên phải là số nguyên.");
                                Console.ResetColor();
                                break;
                            }
                            #endregion
                            Console.ResetColor();
                            if (danhSachSV.ListSV.SingleOrDefault(x => x.MSSV == MSSV) == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Không tìm thấy sinh viên, vui lòng nhập lại");
                                Console.ResetColor();
                            }
                            else break;
                        }
                        //Kiem tra Ma mon hoc
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Nhập mã môn học cần nhập điểm: ");
                            MaMH = Console.ReadLine();
                            Console.ResetColor();
                            if (danhSachMH.ListMH.SingleOrDefault(x => x.MaMH == MaMH) == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Không tìm thấy môn học, vui lòng nhập lại");
                                Console.ResetColor();
                            }
                            else if (danhSachMonDangKy.ListMonDangKy.Where(x => (x.MaMH == MaMH) && (x.MSSV == MSSV)).Count() == 0)
                            {
                                danhSachMonDangKy.NhapDiemSinhVien(MSSV, MaMH);
                                res = true;
                                break;
                            }
                            else
                            {
                                res = false;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Môn học đã nhập điểm.");
                                Console.ResetColor();
                                break;
                            }

                        }
                        if (!res) break;
                        write_json = JsonConvert.SerializeObject(danhSachMonDangKy.ListMonDangKy.ToArray(), Formatting.Indented);
                        File.WriteAllText("../../Data/Mondangky.json", write_json);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nhập điểm thành công");
                        Console.ResetColor();
                        break;
                    case 6:
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Nhập mã sinh viên cần xem kết quả: ");
                            #region MSSV is an integer
                            res = int.TryParse(Console.ReadLine(), out MSSV);
                            if (!res)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Mã sinh viên phải là số nguyên.");
                                Console.ResetColor();
                                break;
                            }
                            #endregion
                            Console.ResetColor();
                            if (danhSachSV.ListSV.SingleOrDefault(x => x.MSSV == MSSV) == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Không tìm thấy sinh viên, vui lòng nhập lại");
                                Console.ResetColor();
                            }
                            else break;
                        }
                        if (!res) break;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "Tên môn học", "Điểm quá trình", "Điểm thành phần", "Điểm tổng kết", "Kết quả");
                        Console.ResetColor();
                        List<MonDangKy> ListKetQua = danhSachMonDangKy.ListMonDangKy.Where(x => x.MSSV == MSSV).ToList();
                        double DiemTongKet;
                        foreach (MonDangKy item in ListKetQua)
                        {
                            DiemTongKet = Math.Round((item.DQT + item.DTP) / 2, 2);
                            if (DiemTongKet >= 4)
                            {
                                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", danhSachMH.ListMH.SingleOrDefault(x => x.MaMH == item.MaMH).TenMH, item.DQT, item.DTP, DiemTongKet, "Đỗ");
                            }
                            else
                            {
                                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", danhSachMH.ListMH.SingleOrDefault(x => x.MaMH == item.MaMH).TenMH, item.DQT, item.DTP, DiemTongKet, "Trượt");
                            }

                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nhập sai vui lòng nhập lại.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }

}