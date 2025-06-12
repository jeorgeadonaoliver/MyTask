import { ReactNode } from "react";

interface CardProps{
    title: string;
    icon: ReactNode;
    children?: ReactNode;
    //onClick?: () => void;
}

const Card = ({ title, icon, children }: CardProps) => {

    return (
       <>
       <div className="bg-white p-6 rounded-4xl dark:bg-neutral-800 dark:border-neutral-700 border-2 border-neutral-300">
            {(title || icon) && (
                 <div className="flex items-center justify-between">
                    <h1 className="text-2xl font-bold">{title}</h1>
                    <div className="mt-2 text-sm text-gray-600 dark:text-gray-400">
                        {icon}
                    </div>
                </div>
            )}
            {children}
       </div>
       </>
    );
};

export default Card;