import { BiLogOut } from "react-icons/bi";
import IconButton from "./icon-button";
import { useRouter } from "next/navigation";
import useLogoutUserMutation from "@/features/authentication/services/useLogoutUserMutation";

const LogoutButton = () => {
    const router = useRouter();
    const logout = useLogoutUserMutation({onSuccessRedirect: (url) => router.push(url)});
    const handleClick = () => logout.mutate();

    return(
        <>
            <div className="pb-4 overflow-hidden" onClick={handleClick}>
                <IconButton icon={<BiLogOut size={30} />} text={"Logout"} /> 
            </div>
        </>
    );
};

export default LogoutButton;