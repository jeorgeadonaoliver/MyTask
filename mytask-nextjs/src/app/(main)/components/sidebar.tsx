import { PiAndroidLogoFill, PiUserListFill } from "react-icons/pi";
import { BiLogOut } from "react-icons/bi";
import { FaHome, FaTasks } from "react-icons/fa";
import { GoProjectSymlink } from "react-icons/go";
import Icon from "../../shared/components/icon";

const Sidebar = () => {

    return (
        <div className="fixed top-0 left-0 h-screen w-22 m-0 flex flex-col 
        dark:bg-neutral-800 dark:border-neutral-700 border-r-2 border-neutral-700 text-white">

            <div className="hover:scale-120">
                <Icon icon={<PiAndroidLogoFill size={30} />} text={""} />
            </div>
            <div className="flex-grow overflow-x-hidden scrollbar-thin scrollbar-thumb-gray-500 scrollbar-track-gray-800">
                <div className="hover:scale-120">
                    <Icon icon={<FaHome size={30} />} text={"Home"} /> 
                </div>
                <div className="hover:scale-125">
                    <Icon icon={<FaTasks size={30}/>} text={"My Task"} /> 
                </div>
                <div className="hover:scale-125">
                    <Icon icon={<PiUserListFill size={30}/>} text={"Users"} /> 
                </div>
                <div className="hover:scale-120">
                    <Icon icon={<GoProjectSymlink size={30} />} text={"Projects"} /> 
                </div>   
            </div>
            <div className="pb-4 hover:scale-120">
                <Icon icon={<BiLogOut size={30} />} text={"Logout"} /> 
            </div>
        </div>
    );
};


export default Sidebar;