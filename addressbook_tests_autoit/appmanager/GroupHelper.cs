﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();
            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i =  0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#"+i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
                                }
            CloseGroupsDialog();
            return list;

        }

        public void RemoveGroup(int v)
        {
            OpenGroupsDialog();
            SelectGroup(v);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait("Delete group");
            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GROUPWINTITLE);
        }

        public void SelectGroup(int v)
        {
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#"+v, "");
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialog();
        }

        public void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }

}
