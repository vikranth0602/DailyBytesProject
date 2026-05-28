using System;
using System.Collections.Generic;

namespace DailyBytesDAL.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ArticleId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
