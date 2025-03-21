using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Caesar_45_Phu;

namespace UnitTestCaesar_45_Phu
{
    [TestClass]
    public class UnitTest1
    {
        private Caesar_45_Phu.Caesar_45_Phu form_45_Phu;

        [TestInitialize]
        public void Setup_45_Phu()
        {
            form_45_Phu = new Caesar_45_Phu.Caesar_45_Phu();
        }

        // 1. Kỹ thuật Phân vùng tương đương (Equivalence Partitioning - EP)
        [TestMethod]
        public void TC01_EP_Encrypt_ValidString_ReturnsCorrectOutput_45_Phu()
        {
            // Phân vùng: Chuỗi hợp lệ, k và n dương
            string result_45_Phu = CaesarCipher_45_Phu.Encrypt_45_Phu("HELLO", 3, 26);
            Assert.AreEqual("KHOOR", result_45_Phu, "EP: Chuỗi hợp lệ phải mã hóa đúng");
            // Pass vì: "HELLO" thuộc phân vùng chuỗi chữ cái hợp lệ, k=3 và n=26 hợp lệ, kết quả đúng theo thuật toán
        }

        [TestMethod]
        public void TC02_EP_Decrypt_ValidString_ReturnsCorrectOutput_45_Phu()
        {
            // Phân vùng: Chuỗi hợp lệ, k và n dương
            string result_45_Phu = CaesarCipher_45_Phu.Decrypt_45_Phu("KHOOR", 3, 26);
            Assert.AreEqual("HELLO", result_45_Phu, "EP: Chuỗi hợp lệ phải giải mã đúng");
            // Pass vì: "KHOOR" thuộc phân vùng chuỗi chữ cái hợp lệ, k=3 và n=26 hợp lệ, giải mã đúng về "HELLO"
        }

        [TestMethod]
        public void TC03_EP_Encrypt_SpecialCharacters_PreservesNonLetters_45_Phu()
        {
            // Phân vùng: Chuỗi chứa ký tự đặc biệt
            string result_45_Phu = CaesarCipher_45_Phu.Encrypt_45_Phu("A#B", 1, 26);
            Assert.AreEqual("B#C", result_45_Phu, "EP: Ký tự đặc biệt phải giữ nguyên");
            // Pass vì: Chỉ chữ cái được mã hóa, ký tự đặc biệt (#) giữ nguyên
        }

        [TestMethod]
        public void TC04_EP_Decrypt_SpecialCharacters_PreservesNonLetters_45_Phu()
        {
            // Phân vùng: Chuỗi chứa ký tự đặc biệt
            string result_45_Phu = CaesarCipher_45_Phu.Decrypt_45_Phu("B#C", 1, 26);
            Assert.AreEqual("A#B", result_45_Phu, "EP: Ký tự đặc biệt phải giữ nguyên");
            // Pass vì: Chỉ chữ cái được giải mã, ký tự đặc biệt (#) giữ nguyên
        }

        // 2. Kỹ thuật Phân tích giá trị biên (Boundary Value Analysis - BVA)
        [TestMethod]
        public void TC05_BVA_Encrypt_KMin_ReturnsOriginal_45_Phu()
        {
            // Giá trị biên dưới của k: 0
            string result_45_Phu = CaesarCipher_45_Phu.Encrypt_45_Phu("ABC", 0, 26);
            Assert.AreEqual("ABC", result_45_Phu, "BVA: k = 0 không dịch chuyển");
            // Pass vì: k = 0 là biên dưới, không thay đổi input, đúng logic
        }

        [TestMethod]
        public void TC06_BVA_Decrypt_KMin_ReturnsOriginal_45_Phu()
        {
            // Giá trị biên dưới của k: 0
            string result_45_Phu = CaesarCipher_45_Phu.Decrypt_45_Phu("ABC", 0, 26);
            Assert.AreEqual("ABC", result_45_Phu, "BVA: k = 0 không dịch chuyển");
            // Pass vì: k = 0 là biên dưới, không thay đổi input, đúng logic
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC07_BVA_Encrypt_NMin_ThrowsException_45_Phu()
        {
            // Giá trị biên dưới của n: 1
            CaesarCipher_45_Phu.Encrypt_45_Phu("ABC", 2, 1);
            // Fail vì: n = 1 không hợp lệ (phải lớn hơn 1), ném ngoại lệ ArgumentException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC08_BVA_Decrypt_NMin_ThrowsException_45_Phu()
        {
            // Giá trị biên dưới của n: 1
            CaesarCipher_45_Phu.Decrypt_45_Phu("ABC", 2, 1);
            // Fail vì: n = 1 không hợp lệ (phải lớn hơn 1), ném ngoại lệ ArgumentException
        }

        // 3. Kỹ thuật Bảng quyết định (Decision Table - DT)
        [TestMethod]
        public void TC09_DT_ValidateInputs_ValidInput_ReturnsTrue_45_Phu()
        {
            // Điều kiện: Input có nội dung, k dương, n dương
            form_45_Phu.txtInput_45_Phu.Text = "TEST";
            form_45_Phu.txtK_45_Phu.Text = "3";
            form_45_Phu.txtN_45_Phu.Text = "26";
            bool valid_45_Phu = form_45_Phu.ValidateInputs_45_Phu(out int k_45_Phu, out int n_45_Phu, out string input_45_Phu);
            Assert.IsTrue(valid_45_Phu, "DT: Tất cả điều kiện hợp lệ phải trả về true");
            Assert.AreEqual(3, k_45_Phu);
            Assert.AreEqual(26, n_45_Phu);
            Assert.AreEqual("TEST", input_45_Phu);
            // Pass vì: Tất cả điều kiện đều thỏa mãn, hàm validate đúng
        }

        [TestMethod]
        public void TC10_DT_ValidateInputs_EmptyInput_ReturnsFalse_45_Phu()
        {
            // Điều kiện: Input rỗng, k dương, n dương
            form_45_Phu.txtInput_45_Phu.Text = "";
            form_45_Phu.txtK_45_Phu.Text = "3";
            form_45_Phu.txtN_45_Phu.Text = "26";
            bool valid_45_Phu = form_45_Phu.ValidateInputs_45_Phu(out int k_45_Phu, out int n_45_Phu, out string input_45_Phu);
            Assert.IsFalse(valid_45_Phu, "DT: Input rỗng phải trả về false");
            // Pass vì: Input rỗng vi phạm điều kiện, hàm validate từ chối đúng
        }

        [TestMethod]
        public void TC11_DT_ValidateInputs_NegativeK_ReturnsFalse_45_Phu()
        {
            // Điều kiện: Input có nội dung, k âm, n dương
            form_45_Phu.txtInput_45_Phu.Text = "TEST";
            form_45_Phu.txtK_45_Phu.Text = "-1";
            form_45_Phu.txtN_45_Phu.Text = "26";
            bool valid_45_Phu = form_45_Phu.ValidateInputs_45_Phu(out int k_45_Phu, out int n_45_Phu, out string input_45_Phu);
            Assert.IsFalse(valid_45_Phu, "DT: k âm phải trả về false");
            // Pass vì: k âm vi phạm điều kiện, hàm validate từ chối đúng
        }

        [TestMethod]
        public void TC12_DT_ValidateInputs_NegativeN_ReturnsFalse_45_Phu()
        {
            // Điều kiện: Input có nội dung, k dương, n âm
            form_45_Phu.txtInput_45_Phu.Text = "TEST";
            form_45_Phu.txtK_45_Phu.Text = "3";
            form_45_Phu.txtN_45_Phu.Text = "-26";
            bool valid_45_Phu = form_45_Phu.ValidateInputs_45_Phu(out int k_45_Phu, out int n_45_Phu, out string input_45_Phu);
            Assert.IsFalse(valid_45_Phu, "DT: n âm phải trả về false");
            // Pass vì: n âm vi phạm điều kiện, hàm validate từ chối đúng
        }

        // 4. Kỹ thuật Dịch chuyển trạng thái (State Transition - ST)
        [TestMethod]
        public void TC13_ST_EncryptThenDecrypt_ReturnsOriginal_45_Phu()
        {
            // Trạng thái: Nguyên bản -> Mã hóa -> Giải mã
            string original_45_Phu = "HELLO";
            string encrypted_45_Phu = CaesarCipher_45_Phu.Encrypt_45_Phu(original_45_Phu, 4, 26); // S1 -> S2
            string decrypted_45_Phu = CaesarCipher_45_Phu.Decrypt_45_Phu(encrypted_45_Phu, 4, 26); // S2 -> S3
            Assert.AreEqual(original_45_Phu, decrypted_45_Phu, "ST: Phải quay lại chuỗi gốc");
            // Pass vì: Dịch chuyển trạng thái qua mã hóa và giải mã đúng, trở về trạng thái ban đầu
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC14_ST_EncryptWithInvalidN_ThrowsException_45_Phu()
        {
            // Trạng thái: Nguyên bản -> Mã hóa (n không hợp lệ)
            string original_45_Phu = "ABC";
            CaesarCipher_45_Phu.Encrypt_45_Phu(original_45_Phu, 2, 0); // S1 -> S2 (sai)
            // Fail vì: n = 0 không hợp lệ, ném ngoại lệ ArgumentException
        }

        // 5. Test case bổ sung để thêm trường hợp fail
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC15_Fail_Encrypt_NegativeK_ThrowsException_45_Phu()
        {
            // Trường hợp: k âm, không hợp lệ
            CaesarCipher_45_Phu.Encrypt_45_Phu("ABC", -1, 26);
            // Fail vì: k âm không hợp lệ, ném ngoại lệ ArgumentException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC16_Fail_Decrypt_NegativeK_ThrowsException_45_Phu()
        {
            // Trường hợp: k âm, không hợp lệ
            CaesarCipher_45_Phu.Decrypt_45_Phu("ABC", -1, 26);
            // Fail vì: k âm không hợp lệ, ném ngoại lệ ArgumentException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC17_Fail_Encrypt_NegativeN_ThrowsException_45_Phu()
        {
            // Trường hợp: n âm, không hợp lệ
            CaesarCipher_45_Phu.Encrypt_45_Phu("ABC", 2, -26);
            // Fail vì: n âm không hợp lệ, ném ngoại lệ ArgumentException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TC18_Fail_Decrypt_NegativeN_ThrowsException_45_Phu()
        {
            // Trường hợp: n âm, không hợp lệ
            CaesarCipher_45_Phu.Decrypt_45_Phu("ABC", 2, -26);
            // Fail vì: n âm không hợp lệ, ném ngoại lệ ArgumentException
        }

        [TestMethod]
        public void TC19_EP_Encrypt_OnlySpecialCharacters_ReturnsUnchanged_45_Phu()
        {
            // Trường hợp: Chuỗi chỉ chứa ký tự đặc biệt
            string result_45_Phu = CaesarCipher_45_Phu.Encrypt_45_Phu("#$%", 2, 26);
            Assert.AreEqual("#$%", result_45_Phu, "Fail: Chuỗi chỉ chứa ký tự đặc biệt không nên mã hóa");
            // Pass vì: Chuỗi không chứa chữ cái, không mã hóa, trả về nguyên bản
            // Ghi chú: Đây là trường hợp đặc biệt, có thể coi là Pass về mặt logic, nhưng nếu yêu cầu là phải có chữ cái thì sẽ Fail
        }

        [TestMethod]
        public void TC20_EP_Decrypt_OnlySpecialCharacters_ReturnsUnchanged_45_Phu()
        {
            // Trường hợp: Chuỗi chỉ chứa ký tự đặc biệt
            string result_45_Phu = CaesarCipher_45_Phu.Decrypt_45_Phu("#$%", 2, 26);
            Assert.AreEqual("#$%", result_45_Phu, "Fail: Chuỗi chỉ chứa ký tự đặc biệt không nên giải mã");
            // Pass vì: Chuỗi không chứa chữ cái, không giải mã, trả về nguyên bản
            // Ghi chú: Tương tự TC19, có thể coi là Pass về mặt logic, nhưng nếu yêu cầu là phải có chữ cái thì sẽ Fail
        }
    }
}