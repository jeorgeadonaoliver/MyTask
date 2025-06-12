import { useQueryClient } from "@tanstack/react-query";
import IconButton from "./icon-button";
import { TbBellRinging2Filled } from "react-icons/tb";
import HeaderDropdown from "./header-dropdown";

const Header = () => {
    const queryClient = useQueryClient();
    const fullName = queryClient.getQueryData<string>(["fullname"]);

    return (
        <header className="fixed top-0 left-22 w-[calc(100%-100px)] shadow-md p-4 flex justify-between items-center bg-stone-950">
            <h1 className="text-lg font-bold">My Header</h1>
            <div className="flex gap-4">
                <div className="hover:scale-125 text-white">
                    <IconButton icon={<TbBellRinging2Filled size={25} />} text={""} /> 
                </div>
                <div className="text-white flex items-center justify-center align-middle gap-2">
                    <HeaderDropdown src={"/avatar.jpg"} alt={"Profile Picture"} width={125} height={125}></HeaderDropdown>
                    <p>{fullName}</p>
                </div>
                
            </div>
        </header>
    );
};

export default Header;