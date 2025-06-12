'use client'

import Header from "@/shared/components/header";
import Sidebar from "@/shared/components/sidebar";


const MainLayout = ({children}: {children: React.ReactNode}) =>{
     
    return(
      <div className="min-h-screen bg-stone-950 flex">
      <aside className="w-22">
        <Sidebar></Sidebar>
      </aside>
      <div className="min-h-screen w-full rounded-l-4xl overflow-x-hidden">
        <div className="flex-1 p-6">
          <div className="ml-[88px]">
            <Header></Header>
          </div>
            {children}
        </div>
      </div>
    </div>
    );
     
}

export default MainLayout;