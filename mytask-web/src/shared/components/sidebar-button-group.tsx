import React from "react";

interface SidebarButtonGroupProps {
    icons: React.ReactNode[];
};

const SidebarButtonGroup = ({ icons }: SidebarButtonGroupProps) => {

    const [activeIndex, setActiveIndex] = React.useState<number>(0);

    return (
        <div>
            {icons.map((icon, index) => (
                <div
                    key={index}
                    className={`rounded-2xl w-21 p-0 ${activeIndex === index ? 'text-white bg-neutral-700' : 'text-white bg-neutral-800'}`}
                    onClick={() => setActiveIndex(index)}>
                    {icon}
                </div>
            ))}
        </div>
    );


};

export default SidebarButtonGroup;