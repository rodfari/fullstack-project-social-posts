import {
  useCallback,
  useContext,
  useEffect,
  useMemo,
  useRef,
  useState,
} from "react";
import FilterBox from "./FilterBox";
import Posts from "./Posts";
import { getPosts } from "../../services/api-services";
import { UserContext } from "../../context/UserContext";
import { AppContext } from "../../context/AppContext";
import { useTimeLine } from "../../hooks/useTimeLine";
import { TimelineContext } from "../../context/TimeLineContext";

const Content = () => {
  //const ctx = useContext(AppContext);
  const tmlCtx = useContext(TimelineContext);
  const userCtx = useContext(UserContext);

  const { posts, actions, params, setParam, refresh, setRefresh, forceRefresh } = useTimeLine(null, null);

  //const [posts, setPosts] = useState([]);

  // useEffect(() => {
  //   console.log("params has changed");
  //   console.log(params);
  //   getPosts(params.page, params.pageSize, params.search, params.sort).then(
  //     (request) => {
  //       if (request.data.length === 0) return;
  //       setPosts((prev) => {
  //         if (params.page < 2) return request.data;
  //         return [...prev, ...request.data];
  //       });
  //     }
  //   );
  // }, [params.page, params.pageSize, params.search, params.sort, refresh]);

  const observer = useRef();
  const lastPostElementRef = useCallback((node) => {
    if (observer.current) observer.current.disconnect();
    observer.current = new IntersectionObserver((entries) => {
      if (entries[0].isIntersecting) {
        // console.log("visible");
        tmlCtx.setPage((prev) => prev + 1);
        setParam({
          type: actions.SET_PAGE,
          payload: tmlCtx.page + 1,
        });
      }
    });
    if (node) observer.current.observe(node);
  }, []);

  return (
    <>
      <TimelineContext.Provider value={{ setParam: setParam, setRefresh }}>
        <div className="content">
          <FilterBox />

          {!posts && <p>Loading...</p>}
          {posts.length === 0 && (
            <div className="no-posts">
              <p>No posts found</p>
            </div>
          )}

          {posts.map((post, index) =>
            index === posts.length - 1 && posts.length >= 15 ? (
              <Posts
                ref={lastPostElementRef}
                post={post}
                userId={userCtx.user.id}
                key={post.postId}
              />
            ) : (
              <Posts post={post} userId={userCtx.user.id} key={post.postId} />
            )
          )}
        </div>
      </TimelineContext.Provider>
    </>
  );
};

export default Content;
