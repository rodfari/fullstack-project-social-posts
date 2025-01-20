import { createContext } from "react";

export const ModalContext = createContext({
    flag: false,
    setModal: () => {},
    toggleModal: () => {},
    
});