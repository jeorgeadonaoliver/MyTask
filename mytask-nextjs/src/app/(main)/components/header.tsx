'use client';

import Icon from "@/app/shared/components/icon";
import { TbBellRinging2Filled } from "react-icons/tb";
import HeaderImageDropdown from "./header-image-dropdown";
import { useQueryClient } from "@tanstack/react-query";

const Header = () => {
    const queryClient = useQueryClient();
    const fullName = queryClient.getQueryData<string>(["fullname"]);

    return (
        <header className="fixed top-0 left-22 w-[calc(100%-100px)] shadow-md p-4 flex justify-between items-center bg-stone-950">
            <h1 className="text-lg font-bold">My Header</h1>
            <div className="flex gap-4">
                <div className="hover:scale-125 text-white">
                    <Icon icon={<TbBellRinging2Filled size={25} />} text={""} /> 
                </div>
                <div className="text-white flex items-center justify-center align-middle gap-2">
                    <HeaderImageDropdown src={"/avatar.jpg"} alt={"Profile Picture"} width={125} height={125}></HeaderImageDropdown>
                    <p>{fullName}</p>
                </div>
                
            </div>
        </header>
    );
};

export default Header;