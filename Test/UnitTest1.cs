
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task_14_10_1;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FromUserController_ShouldReturnTrue_IfPasswordLengthIsIsInTheWrongFormat()
        {
            string passwordInString = "qwerr";
            bool result = Program.FromUserController(passwordInString, out int passwordLength);
           Assert.IsTrue(result);
        }
        [Test]
        public void FromUserYesController_ShouldReturnFalse_If()
        {
            string fromUser = "qwerty";
            bool result = Program.FromUserYesController(fromUser);
            Assert.IsFalse(result);
        }

        [Test]
        public void SumChars_ShouldReturnArrayWhichIsSumOfTwoArraysAndHasCorrectLength()
        {
            char[] ArrayofChars ={ '1','3','5'};
            char[] ArrayofChars2 = { '6', '7', '8' };
            char[] ArrayofChars3 = { '1', '3', '5', '6', '7', '8' };
            int result = (Program.SumChars(ArrayofChars, ArrayofChars2,ArrayofChars3).Length);
            Assert.AreEqual(ArrayofChars3.Length, result);
        }
        [Test]
        public void SumChars_ShouldReturnArrayWhichIsSumOfTwoArray()
        {
            char[] ArrayofChars = { '1', '3', '5' };
            char[] ArrayofChars2 = { '6', '7', '8' };
            char[] ArrayofChars3 = { '1', '3', '5', '6', '7', '8' };
            char[] ArrayofChars4 = Program.SumChars(ArrayofChars, ArrayofChars2, ArrayofChars3);
            Assert.AreSame(ArrayofChars3, ArrayofChars4);
        }
        [Test]
        public void PasswordController_ShouldReturnFalseForTooSmallPasswordLenght()
        {
            int count = 9;
            int passwordLength = 5;
            bool result = Program.PasswordLengthController(passwordLength, count);
            Assert.IsFalse(result);
        }
        [Test]
        public void passwordGenerator_ShouldCreateArrayOfCorrectLength()
        {

            int count = 2;
            int passwordLength = 5;
            string alltypesOfChar = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            int lengthOfChar = passwordLength - count;
            int result = (Program.passwordGenerator(alltypesOfChar, passwordLength, count)).Length;
            Assert.AreEqual(lengthOfChar, result);
        }
        [Test]
        public void passwordGenerator_ShouldReturnFalseForArrayOfIncorrectChars()
        {

            int count = 3;
            int passwordLength = 9;
            string alltypesOfChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            char[] ArrayofChars = Program.passwordGenerator(alltypesOfChars, passwordLength, count);
            bool result=true;
            foreach (var item in ArrayofChars)
            {
                if (!alltypesOfChars.Contains(item))
                {
                    result = false;
                    break;
                }
            }
            Assert.IsTrue(result);
        }
        [Test]
        public void Shuffle_ShouldReturnOtherArrayOfChars()
        {
            char[] ArrayofChars = { '1', '2' };
            char[] ArrayofChars1 = {'1','2'};
            

            Program.Shuffle(ArrayofChars1);
            Assert.AreNotSame(ArrayofChars, ArrayofChars1);
        }
        [Test]
        public void GoodRandoms_ShouldReturnArraywithCorectLength()
        {
            int count=4;
            string allTypesOfChar = "QWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*()-_=+<,>.0123456789qwertyuiopasdfghjklzxcvbnm";
            Dictionary<string, string> DictionaryOfCharacters = new Dictionary<string, string>();
            DictionaryOfCharacters.Add("capital_letters", "QWERTYUIOPASDFGHJKLZXCVBNM");
            char[] ArrayofChars = Program.GoodRandoms(DictionaryOfCharacters,count,allTypesOfChar);
            int result = ArrayofChars.Length;
            Assert.AreEqual(count, result);
        }
        [Test]
        public void GoodRandomsForArraywithCorectChars_ShouldReturnTrue()
        {
            int count = 2;
            string allTypesOfChar = "QWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*()-_=+<,>.";
            Dictionary<string, string> DictionaryOfCharacters = new Dictionary<string, string>();
            DictionaryOfCharacters.Add("capital_letters", "QWERTYUIOPASDFGHJKLZXCVBNM");
            DictionaryOfCharacters.Add("special_characters", "!@#$%^&*()-_=+<,>.");
            char[] ArrayofChars = Program.GoodRandoms(DictionaryOfCharacters, count, allTypesOfChar);
            bool result=true;
            foreach (var item in ArrayofChars)
            {
                if (!allTypesOfChar.Contains(item))
                {
                    result = false;
                    break;
                }
            }
            Assert.IsTrue(result);
        }

    }
}