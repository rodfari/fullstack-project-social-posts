import { useCallback, useContext, useEffect, useRef, useState } from "react";
import FilterBox from "./FilterBox";
import Posts from "./Posts";
import { AppContext } from "../../../context/AppContext";
import { getPosts } from "../../../services/api-services";

const Content = () => {
  const appCtx = useContext(AppContext);
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    getPosts(appCtx.search, appCtx.sort).then((data) => {
      setPosts(data);
    });
  }, [appCtx.updatePost, appCtx.search, appCtx.sort, appCtx.repost]);

  const observer = useRef();
  const lastPostElementRef = useCallback((node) => {
    if(observer.current) observer.current.disconnect();
    observer.current = new IntersectionObserver(entries => {
      if(entries[0].isIntersecting) {
        console.log('visible');
      };
    });
    if(node) observer.current.observe(node);
    console.log(node);
  },[]);


  return (
    <>
      <div className="content">
        <FilterBox />

        { !posts && <p>Loading...</p> }
        { posts.length === 0 && (
          <div className="no-posts">
            <p>No posts found</p>
          </div>
        )}

        {posts.map((post, index) => (
          index === posts.length - 1 ? (
              <Posts
                ref={lastPostElementRef}
                post={post}
                userId={appCtx.user.id}
                key={post.postId}
              />
            ) : (
              <Posts post={post} userId={appCtx.user.id} key={post.postId} />
            )
        ))}
      </div>
    </>
  );
};

export default Content;
