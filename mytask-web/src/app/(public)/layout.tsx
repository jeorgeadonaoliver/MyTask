import React from "react";

const PublicLayout = ({children}: {children: React.ReactNode}) => {
    return(
        <div className="min-h-screen w-screen bg-stone-950">
            {children}
        </div>
    );
}

export default PublicLayout;