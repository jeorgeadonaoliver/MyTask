interface SidebarLogoProps {
    icon: React.ReactNode;
    text: string;
};

const IconButton = ({icon, text}:SidebarLogoProps) => {
    return (
        <div className="p-1 hover:scale-120 transition-transform duration-300">
            <div className="mt-4 mb-4 flex flex-col items-center justify-center text-center">
                {icon}
                <span className="text-[12px] font-bold">{text}</span>
            </div>
        </div>
    );
};

export default IconButton;