using Nungning.BLL.Info;
using Nungning.BLL.Provider;
using NungningUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Controller
{
    public class WebboardController
    {
        public static List<TopicInfo> getTopic(string topic_id)
        {
            return CBO.FillCollection<TopicInfo>(DataProvider.Instance().GetTopic(topic_id));
        }

        public static TopicInfo addTopic(TopicInfo topic)
        {
            return CBO.FillObject<TopicInfo>(DataProvider.Instance().AddTopic(topic));
        }

        public static TopicInfo setToppic(TopicInfo topic)
        {
            return CBO.FillObject<TopicInfo>(DataProvider.Instance().SetTopic(topic)); ;
        }

        //comment
        public static List<CommentInfo> getComment(string comment_id , string topic_id)
        {
            return CBO.FillCollection<CommentInfo>(DataProvider.Instance().GetComment(comment_id , topic_id));
        }

        public static CommentInfo addComment(CommentInfo comment)
        {
            return CBO.FillObject<CommentInfo>(DataProvider.Instance().AddComment(comment)); ;
        }

        public static CommentInfo setComment(CommentInfo comment)
        {
            return CBO.FillObject<CommentInfo>(DataProvider.Instance().SetComment(comment)); ; ;
        }
    }
}
