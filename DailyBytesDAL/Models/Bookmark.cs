using System;
using System.Collections.Generic;

namespace DailyBytesDAL.Models;

public partial class Bookmark
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ArticleId { get; set; }

    public virtual Article? Article { get; set; }

    public virtual User? User { get; set; }
}
