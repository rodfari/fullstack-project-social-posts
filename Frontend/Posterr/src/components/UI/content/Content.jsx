import { useEffect, useState, useContext } from "react";
import FilterBox from "./FilterBox";
import  Posts  from "./Posts";
import { getPosts } from "../../../services/api-services";
import { ModalContext } from "../../../context/ModalContext";

const Content = () => {
  const modalContext = useContext(ModalContext);
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    getPosts().then((data) => {
      setPosts(data);
    });
  }, [modalContext.updatePost]);

  return (
    <>
      <div className="content">
        <FilterBox />
        <Posts data={posts} />
      </div>
    </>
  );
};

export default Content;
