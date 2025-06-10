import Image from "next/image";
import { useState } from "react";

interface HeaderImageDropdownProps {
    src: string;
    alt: string;
    width?: number | undefined;
    height?: number | undefined;
};


const HeaderImageDropdown = ({src,alt,width,height}: HeaderImageDropdownProps) => {
    const [open, setOpen] = useState(false);

    return(
        <div className="relative">
            <div className="w-9 h-10 rounded-full overflow-hidden">
                <Image
                    src={src}
                    alt={alt}
                    width={width}
                    height={height}
                    className="w-full h-full object-cover"
                    onClick={() => setOpen(!open)}
                />
                {open && (
                   <div className="absolute right-0 mt-2 w-40 bg-white shadow-md rounded-lg">
                    <ul className="py-2 text-gray-700">
                        <li className="px-4 py-2 hover:bg-gray-100 cursor-pointer">Option 1</li>
                        <li className="px-4 py-2 hover:bg-gray-100 cursor-pointer">Option 2</li>
                        <li className="px-4 py-2 hover:bg-gray-100 cursor-pointer">Option 3</li>
                    </ul>
                </div>)}           
            </div>    
        </div>
        
    );
};

export default HeaderImageDropdown;