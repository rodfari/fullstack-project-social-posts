import { useEffect, useState } from "react";
import "./App.sass";
import { getPosts } from "./services/api-services";
import Content from "./components/UI/content/Content";
import Modal from "./components/Modal";
import { AppContext } from "./context/AppContext";
import Sidebar from "./components/UI/Sidebar";

function App() {
  const [modal, setModal] = useState(false);
  const [updatePost, setUpdatePosts] = useState(false);
  const [sort, setSort] = useState("newest");
  const [search, setSearch] = useState("");
  const toggleModal = () => {
    setModal((prev) => (prev ? false : true));
  };

  const contextProvide = {
    toggleModal,
    updatePost,
    setUpdatePost: setUpdatePosts,
    sort,
    setSort,
    search,
    setSearch
  }

  return (
    <AppContext.Provider
      value={ contextProvide }
    >
      <div className="container">
        <Sidebar />
        <Content />
      </div>
      {modal && <Modal />}
    </AppContext.Provider>
  );
}

export default App;
