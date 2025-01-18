## Overview

The Project Manager you work with wants to build a new product, a new social media application called Posterr. 

Posterr is very similar to Twitter, but it has far fewer features. It only has one page which's described below. Other data and actions are also detailed below. 

**Homepage**

- By default, the homepage will display a feed of posts (including reposts) starting with the latest 15 posts. Older posts are loaded on-demand in chunks of 20 posts whenever the user scrolls to the bottom of the page. -- IN PROGRESS
- New posts can be written from this page. -- DONE
- Users can repost existing posts unless the content is a repost. -- DONE
- A search input allows results filtering by keywords -- DONE

### More Details

**Users**

- Users have unique alphanumeric usernames -- DONE
- Do not build an authentication logic -- OK
- Do not build CRUD for users (registration and sign-in will be handled by a different service, the user model should be part of your data modeling tho. You can seed the database with 4 users to help the reviewer demo your solution) -- DONE
- When/if necessary to make your application function, you may hard-code the default user (or have a setting for that). For instance, you may need to do this to implement creating new posts. -- DONE - using migrations.

**Posts**

Posts are the equivalent of Twitter's tweets. They are text-only, user-generated content. Users can write original posts and interact with other users' posts by reposting content. For this project, you should implement both — original posts, and reposts. -- DONE

- A user is not allowed to post more than 5 posts in one day (including reposts) -- DONE  
- Posts can have a maximum of 777 characters -- DONE
- The post rendering should include the author's username and creation date, in addition to the content. -- DONE
- Users cannot update or delete their posts -- OK 
- Users can change the sorting between "latest" and "trending". When choosing "latest" (default), the posts will be rendered in descending order of their creation date. For "trending" posts, those with more reposts should come first. -- DONE
- When filtering results using keywords, only exact matches for post content are expected. -- DONE
- Only original posts are expected as a result of the keywords filtering -- DONE

**Reposting**

- //TODO Users can repost other users' posts (like Twitter Retweet), limited to original posts 
- Users must confirm their intention when reposting. -- DONE
- //TODO It should **not** be possible to repost the same post twice 



## Phase 1, coding

Estimated time: 6.5 hours

- Build out a RESTful API and corresponding backend system to handle the features detailed above - IN PROGRESS
- Build a single-page application in JavaScript using a framework of your choice, and integrate it with the backend implementation. IN PROGRESS
- You should implement a real, production-ready database, and queries should be performant. DONE
- Do not implement additional features beyond what is explained in the overview. NEED CHECKING...
- //TODO Write automated tests for this project. 
- Make sure you provide a straightforward way to set up your app locally with proper requirements definitions (we strongly recommend a containerized solution and a package manager). DONE

## Phase 2, self-critique & scaling

Estimated time: 30 minutes

In any project, it is always a challenge to get the code perfectly how you'd want it. Here is what you need to do for this section:

- Reflect on this project, and write what you would improve if you had more time. -- IN PROGRESS
- Write about scaling.
    - If this project were to grow and have many users and posts, which parts do you think would fail first? -- IN PROGRESS
    - In a real-life situation, what steps would you take to scale this product? What other types of technology and infrastructure might you need to use? -- IN PROGRESS

This should be added as a section called "Critique" (**please provide as much detail as possible)** in the README.