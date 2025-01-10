import { useEffect, useState } from "react";
import "./App.sass";
import { getPosts } from "./services/api-services";
import Content from "./components/UI/content/Content";
import Modal from "./components/Modal";
import { ModalContext } from "./context/ModalContext";
import Sidebar from "./components/UI/Sidebar";

function App() {
  const [modal, setModal] = useState(false);
  const [updatePost, setUpdatePosts] = useState(false);
  const toggleModal = () => {
    setModal((prev) => (prev ? false : true));
  };

  return (
    <ModalContext.Provider
      value={{
        toggleModal,
        setUpdatePost: setUpdatePosts,
        updatePost
      }}
    >
      <div className="container">
        <Sidebar />
        <Content />
      </div>
      {modal && <Modal />}
    </ModalContext.Provider>
  );
}

export default App;
