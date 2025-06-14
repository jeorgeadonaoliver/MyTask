import { IoHomeOutline } from "react-icons/io5";
import IconButton from "./icon-button";
import { GoProjectSymlink, GoTasklist } from "react-icons/go";
import { HiOutlineUsers } from "react-icons/hi";
import SidebarButtonGroup from "./sidebar-button-group";
import LogoutButton from "./logout-button";
import Image from "next/image";

const Sidebar = () => {

    const iconGroup : React.ReactNode[] = [ 
        <IconButton key={1} icon={<IoHomeOutline size={28} />} text={"Home"}/>, 
        <IconButton key={2} icon={<GoTasklist size={28}/>} text={"My Task"}/>, 
        <IconButton key={3} icon={<HiOutlineUsers size={28}/>} text={"Users"} />, 
        <IconButton key={4} icon={<GoProjectSymlink size={28} />} text={"Projects"} /> 
    ];

    return (
        <div className="fixed top-0 left-0 h-screen w-20 m-0 flex flex-col dark:bg-neutral-800 text-white">
            <div className="bg-neutral-800 overflow-hidden">
                <IconButton icon={<Image src="/mytask-logo-transparent.png" alt="logo" width={70} height={80}/>} text={""} />
            </div>
            <div className="flex-grow overflow-x-hidden w-19">
               <SidebarButtonGroup icons={iconGroup} />
            </div>
            <LogoutButton />            
        </div>
    );
};


export default Sidebar;