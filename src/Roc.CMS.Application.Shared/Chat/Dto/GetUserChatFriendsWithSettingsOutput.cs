using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using Roc.CMS.Friendships.Dto;

namespace Roc.CMS.Chat.Dto
{
    public class GetUserChatFriendsWithSettingsOutput
    {
        public DateTime ServerTime { get; set; }
        
        public List<FriendDto> Friends { get; set; }

        public GetUserChatFriendsWithSettingsOutput()
        {
            Friends = new EditableList<FriendDto>();
        }
    }
}