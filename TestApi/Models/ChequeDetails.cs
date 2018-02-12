// File: ChequeTest/ChequeTest/ChequeDetails.cs
// User: Adrian Hum/
// 
// Created:  2018-02-12 9:27 AM
// Modified: 2018-02-12 9:29 AM

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestApi.Helpers;

namespace TestApi.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The Object of the cheque
    /// </summary>
    public class ChequeDetails : IValidatableObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fullName">Cheque res Bearer's Full Name</param>
        /// <param name="amount">Decimal Amount for the cheque</param>
        public ChequeDetails(string fullName, decimal amount)
        {

            //try
            //{
            FullName = fullName;
            Amount = amount;
            var res = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(this, new ValidationContext(this, null, null), res, true);
            if (!isValid) throw new ArgumentException(string.Join("\r\n", res));
            //}

            //catch (Exception ex) //Only Included During Debug... It should be refactored out.
            //{
            //    throw;
            //}
        }
        /// <summary>
        /// Bearer's Name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Amount to be represented as words
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Delegate Property Dollar to Words.
        /// </summary>
        public string DollarWords => CurrencyHelper.NumberToWords(Amount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(FullName)) yield return new ValidationResult("The Bearer Name Cannot Be Empty");
        }
        /// <summary>
        /// Overridden ToString to give the objects better visibility.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{FullName}, {Amount}, {DollarWords}";
        }
    }
}