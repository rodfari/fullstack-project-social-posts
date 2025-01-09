import { useEffect, useState } from "react";
import FilterBox from "./FilterBox";
import  Posts  from "./Posts";
import { getPosts } from "../../../services/api-services";

const Content = () => {

  const [posts, setPosts] = useState([]);
  useEffect(() => {
    getPosts().then((data) => {
      setPosts(data);
    });
  }, []);

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
