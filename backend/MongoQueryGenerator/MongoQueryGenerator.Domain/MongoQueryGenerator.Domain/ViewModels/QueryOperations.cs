using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MongoQueryGenerator.Domain.ViewModels
{
    public class QueryOperations
    {
        [Required]
        public QueryOperation[] Operations { get; set; }
    }

    public class QueryOperation
    {
        [Required]
        public String Field { get; set; }

        [Required]
        public ComparisonType ComparisonType { get; set; }

        [Required]
        public ValidTargetTypes ValidTargetTypes { get; set; }

        [Required]
        public object Target { get; set; }
    }

    public enum ComparisonType
    {
        Equals,
        LowerTan,
        HigherTan,
    }

    public enum ValidTargetTypes
    {
        String,
        Any
    }
}

