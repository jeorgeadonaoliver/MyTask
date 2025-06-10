import { PiAndroidLogoFill } from "react-icons/pi";
import { BiLogOut } from "react-icons/bi";
import { GoProjectSymlink, GoTasklist } from "react-icons/go";
import Icon from "../../shared/components/icon";
import SidebarButtonGroup from "./sidebar-button-group";
import React from "react";
import { IoHomeOutline } from "react-icons/io5";
import { HiOutlineUsers } from "react-icons/hi";

const Sidebar = () => {

    const iconGroup : React.ReactNode[] = [ 
        <Icon key={1} icon={<IoHomeOutline size={32} />} text={"Home"}/>, 
        <Icon key={2} icon={<GoTasklist size={32}/>} text={"My Task"}/>, 
        <Icon key={3} icon={<HiOutlineUsers size={32}/>} text={"Users"} />, 
        <Icon key={4} icon={<GoProjectSymlink size={32} />} text={"Projects"} /> 
    ];

    return (
        <div className="fixed top-0 left-0 h-screen w-22 m-0 flex flex-col 
        dark:bg-neutral-800 dark:border-neutral-700 border-r-2 border-neutral-700 text-white">

            <div className="hover:scale-120">
                <Icon icon={<PiAndroidLogoFill size={30} />} text={""} />
            </div>
            <div className="flex-grow overflow-x-hidden scrollbar-thin scrollbar-thumb-gray-500 scrollbar-track-gray-800">
               <SidebarButtonGroup icons={iconGroup} />
            </div>
            <div className="pb-4 hover:scale-120">
                <Icon icon={<BiLogOut size={30} />} text={"Logout"} /> 
            </div>
        </div>
    );
};


export default Sidebar;