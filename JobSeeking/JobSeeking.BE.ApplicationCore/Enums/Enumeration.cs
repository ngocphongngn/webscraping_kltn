using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeking.BE.ApplicationCore.Enums
{
    public class Enumeration
    {
        public enum ProcdureTypeName
        {
            /// <summary>
            ///  Lấy dữ liệu
            /// </summary>
            Get,

            /// <summary>
            /// Lấy dữ liệu theo khóa chính
            /// </summary>
            GetById,

            /// <summary>
            /// Thêm mới
            /// </summary>
            Insert,

            /// <summary>
            /// Sửa/ cập nhật dữ liệu
            /// </summary>
            Update,

            /// <summary>
            /// Xóa dữ liệu
            /// </summary>
            Delete,

            /// <summary>
            /// Lấy dữ liệu có phân trang
            /// </summary>
            GetPaging
        }

        /// <summary>
        /// Kiểu phương thức 
        /// </summary>
        public enum EntityState
        {
            /// <summary>
            /// Lấy dữ liệu
            /// </summary>
            GET,

            /// <summary>
            /// Thêm mới dữ liệu
            /// </summary>
            INSERT,

            /// <summary>
            /// Sửa dữ liệu
            /// </summary>
            UPDATE,

            /// <summary>
            /// Xóa dữ liệu
            /// </summary>
            DELETE
        }

        /// <summary>
        /// Các mã lỗi
        /// </summary>
        public enum SystemCode
        {
            Success = 200,

            /// <summary>
            /// Lỗi validate dữ liệu chung
            /// </summary>
            Validate = 400,

            /// <summary>
            /// Lỗi validate dữ liệu không hợp lệ
            /// </summary>
            ValidateEntity = 401,

            /// <summary>
            /// Lỗi validate dữ liệu do không đúng nghiệp vụ
            /// </summary>
            ValidateBussiness = 402,

            /// <summary>
            /// Lỗi không tìm thấy
            /// </summary>
            NotFound = 404,

            /// <summary>
            /// Lỗi Exception
            /// </summary>
            Exception = 500,

            /// <summary>
            /// Lỗi Trùng dữ liệu
            /// </summary>
            Duplicate = 501,

            /// <summary>
            /// Lỗi File không đúng định dạng
            /// </summary>
            FileFormat = 600,

            /// <summary>
            /// Lỗi File import không đúng định dạng
            /// </summary>
            ImportFileFormat = 601,

            /// <summary>
            /// Lỗi File Export không đúng định dạng
            /// </summary>
            ExportFileFormat = 602,

            /// <summary>
            /// Lỗi thêm mới entity
            /// </summary>
            ErrorAddEntity = 603,

            /// <summary>
            /// Lỗi xóa entity
            /// </summary>
            ErrorDeleteEntity = 604,
            /// <summary>
            /// Lỗi cập nhật entity
            /// </summary>
            ErrorUpdateEntity = 605,
        }

        /// <summary>
        /// Các enum ServerError
        /// </summary>
        public enum ServerEror
        {
            DUPLICATE = 1062,
        }

    }
}
