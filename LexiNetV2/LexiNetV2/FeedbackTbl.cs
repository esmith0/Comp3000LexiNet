//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LexiNetV2
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeedbackTbl
    {
        public int feebackID { get; set; }
        public Nullable<int> readabilityRating { get; set; }
        public Nullable<int> spacingRating { get; set; }
        public Nullable<int> colourRating { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<int> resourceID { get; set; }
        public string reviewerName { get; set; }
    
        public virtual ResourcesTbl ResourcesTbl { get; set; }
        public virtual UserTbl UserTbl { get; set; }
    }
}
