import { useState } from "react";

const useForm = <T extends object>(initial: T) => {

  const [formData, setFormData] = useState<T>(initial);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };
  
  return { formData, handleChange, setFormData };
};

export default useForm;