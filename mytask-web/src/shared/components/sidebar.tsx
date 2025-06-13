import { IoHomeOutline } from "react-icons/io5";
import IconButton from "./icon-button";
import { GoProjectSymlink, GoTasklist } from "react-icons/go";
import { HiOutlineUsers } from "react-icons/hi";
import { PiAndroidLogoFill } from "react-icons/pi";
import SidebarButtonGroup from "./sidebar-button-group";
import LogoutButton from "./logout-button";

const Sidebar = () => {

    const iconGroup : React.ReactNode[] = [ 
        <IconButton key={1} icon={<IoHomeOutline size={32} />} text={"Home"}/>, 
        <IconButton key={2} icon={<GoTasklist size={32}/>} text={"My Task"}/>, 
        <IconButton key={3} icon={<HiOutlineUsers size={32}/>} text={"Users"} />, 
        <IconButton key={4} icon={<GoProjectSymlink size={32} />} text={"Projects"} /> 
    ];

    return (
        <div className="fixed top-0 left-0 h-screen w-22 m-0 flex flex-col 
        dark:bg-neutral-800 dark:border-neutral-700 border-r-2 border-neutral-700 text-white">

            <div className="hover:scale-120">
                <IconButton icon={<PiAndroidLogoFill size={30} />} text={""} />
            </div>
            <div className="flex-grow overflow-x-hidden scrollbar-thin scrollbar-thumb-gray-500 scrollbar-track-gray-800">
               <SidebarButtonGroup icons={iconGroup} />
            </div>
            <LogoutButton />            
        </div>
    );
};


export default Sidebar;